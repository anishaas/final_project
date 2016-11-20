//This file is used to create an object that holds html UI components that can be referenced with other JS files
var htmlComponents = {
    genreListComponent: ''
}

var songSearchURLs = {
    getGenreDataURL: '/data/getGenreData'
}

$(document).ready(function () {
    //Set up the html components in the htmlComponents object so other scripts can easily refer to the html.
    htmlComponents.genreListComponent = $('#genreListComponent')[0].outerHTML;
    htmlComponents.moduleButtonComponent = $('#moduleButtonComponent')[0].outerHTML;
});