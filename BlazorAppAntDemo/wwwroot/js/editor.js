editors = {};

function CreateEditor(editorId, defaultValue, height, dotNetReference) {

  ClassicEditor
    .create(document.getElementById(editorId), {

      toolbar: {
        shouldNotGroupWhenFull: true,
        items: [
          'heading',
          '|',
          'bold',
          'italic',
          'link',
          'bulletedList',
          'numberedList',
          '|',
          'outdent',
          'indent',
          '|',
          'imageUpload',
          'blockQuote',
          'insertTable',
          'mediaEmbed',
          'undo',
          'redo'
        ]
      },
      language: 'en',
      licenseKey: '',
    })

    .then(editor => {
      editors[editorId] = editor;
      editor.editing.view.change(writer => {
        writer.setStyle('height', height, editor.editing.view.document.getRoot());
      });
      editor.setData(defaultValue);
      editor.model.document.on('change:data', () => {
        let data = editor.getData();
        dotNetReference.invokeMethodAsync('OnEditorChanged', data);
      });
    })

    .catch(error => {
      console.error(error);
    });
}

function DestroyEditor(editorId) {
  editors[editorId].destroy().then(() => delete editors[editorId])
    .catch(error => console.log(error));
}