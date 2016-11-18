//This file is used to create an object that holds html UI components that can be referenced with other JS files
var htmlComponents = {
    accordionComponent: '',
}

var surveyURLs = {
    getSurveyHeaderQuestionsURL: ''
}

$(document).ready(function () {
    //Set up the html components in the htmlComponents object so other scripts can easily refer to the html.
    htmlComponents.accordionComponent = $('#accordionComponent')[0].outerHTML;

});