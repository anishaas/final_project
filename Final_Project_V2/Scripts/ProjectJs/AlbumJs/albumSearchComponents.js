//This file is used to create an object that holds html UI components that can be referenced with other JS files
var htmlComponents = {
    genreListComponent: '',
    moduleButtonComponent: '',
    tableDataComponent:''
}

var albumSearchURLs = {
    getGenreDataURL: '/data/getGenreData',
    searchAlbumURL: '/search/albumSearch'
}

$(document).ready(function () {
    //Set up the html components in the htmlComponents object so other scripts can easily refer to the html.
    htmlComponents.genreListComponent = $('#genreListComponent')[0].outerHTML;
    htmlComponents.moduleButtonComponent = $('#moduleButtonComponent')[0].outerHTML;
    htmlComponents.tableDataComponent = $('#tableDataComponent')[0].outerHTML;
});