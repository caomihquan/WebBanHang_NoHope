/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '~/Assets/Admin1/js/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '~/Assets/Admin1/js/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '~/Assets/Admin1/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '~/Assets/Admin1/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '~/Assets/Admin1/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '~/Assets/Admin1/js/plugins/ckfinder/');
};
