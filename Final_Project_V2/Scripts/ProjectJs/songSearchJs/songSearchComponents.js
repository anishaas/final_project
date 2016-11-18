//This file is used to create an object that holds html UI components that can be referenced with other JS files
var htmlComponents = {
    accordionComponent: '',
    accordionComponentExpanded: '',
    cardComponent: '',
    tableComponent: '',
    tableHeaderComponent: '',
    tableRowComponent: ''
}

var surveyURLs = {
    getSurveyHeaderQuestionsURL: '/other/custom/CMSSurvey/getSurveyHeaderQuestions',
    getSurveyQuestionResultsDataURL: '/other/custom/CMSSurvey/getSurveyQuestionResultsData'
}

$(document).ready(function () {
    //Set up the html components in the htmlComponents object so other scripts can easily refer to the html.
    htmlComponents.accordionComponent = $('#accordionComponent')[0].outerHTML;
    htmlComponents.accordionComponentExpanded = $('#accordionComponentExpanded')[0].outerHTML;
    htmlComponents.cardComponent = $('#cardComponent')[0].outerHTML;
    htmlComponents.tableComponent = $('#tableComponent')[0].outerHTML;
    //htmlComponents.tableHeaderComponent = $('#tableHeaderComponent')[0].outerHTML;
    htmlComponents.tableRowComponent = $('#tableRowComponent')[0].outerHTML;
    //htmlComponents.
});