//This holds a js object that makes it easy to call helper functions in the main execution js file
var surveyHelperFunctions = {};
(function (context) {
    //Private scope 



    //Public API's	
    context.test = function () {
        alert('wtf');
    };

    context.stringReplaceHelper = function replaceAll(str, mapObj) {
        var re = new RegExp(Object.keys(mapObj).join("|"), "gi");

        return str.replace(re, function (matched) {
            return mapObj[matched.toLowerCase()];
        });
    };

    context.setupMorrisBar = function setupMorrisBar(elementReference, data) {

        /// WILLIAM HUA ADDED HELPER FUNCTIONS, THESE SHOULD BE TEMP
        function componentToHex(c) {
            var hex = c.toString(16);
            return hex.length == 1 ? "0" + hex : hex;
        }

        function rgbToHex(r, g, b) {
            return "#" + componentToHex(r) + componentToHex(g) + componentToHex(b);
        }

        function applyOpacity(c, opacity) {
            return Math.round((opacity) * (c - 255) + 255);
            //return Math.round((c - (1 - opacity) * 255) / opacity);
        }

        //alert( rgbToHex(0, 51, 255) ); // #0033ff

        function hexToRgb(hex) {
            var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
            return result ? {
                r: parseInt(result[1], 16),
                g: parseInt(result[2], 16),
                b: parseInt(result[3], 16)
            } : null;
        }
        // Get the maximum
        max = -1;
        data.forEach(function (entry) {
            if (parseInt(entry.y) > parseInt(max)) {
                max = entry.y;
            }
        });

        // This is the bar graph for the module summaries
        if (elementReference.length > 0) {
            Morris.Bar({
                element: elementReference,
                data: data,
                xkey: 'x',
                ykeys: ['y'],
                labels: ['Count'],
                horizontal: true,
                hideHover: true,
                barColors: function (row, series, type) {
                    var y = series.key;
                    var ratio = row.y / max;
                    console.log("ROW: " + row.y + " MAX: " + max);
                    var percentageAlpha = 0.5 + (ratio / 2);
                    var origHexString = elementReference.data("color")
                    var rgb = hexToRgb(origHexString);
                    rgb.r = applyOpacity(rgb.r, percentageAlpha);
                    rgb.g = applyOpacity(rgb.g, percentageAlpha);
                    rgb.b = applyOpacity(rgb.b, percentageAlpha);

                    var hex = rgbToHex(rgb.r, rgb.g, rgb.b);
                    return hex;
                },

            });
        }
    };

    context.refreshData = function refreshData() {
        //Look for all uncollapsed questions
        var questionTitles = $('.questionTitle');
        questionTitles.each(function () {
            if (!$(this).parent().hasClass('card-collapsed')) {
                $(this).next().find('.questionDetail').empty();
                var surveyQuestionId = $(this).attr('data-question-detail-id');
                var surveyQuestionType = $(this).attr('data-question-type-id');
                var dataContainer = $(this).next().find('.questionDetail');

                //Get survey question results and display to user
                $.post(surveyURLs.getSurveyQuestionResultsDataURL, { surveyQuestionId: surveyQuestionId })
                .done(function (data) {
                    var surveyResultsData = jQuery.parseJSON(data);
                    if (surveyQuestionType == 1) {
                        //Convert the data to provide into the chart module
                        var morrisDataObject = [];

                        $.each(surveyResultsData, function (index, answerResult) {
                            var answerResultObject = { x: '', y: '' };
                            answerResultObject.x = index;
                            answerResultObject.y = answerResult;
                            morrisDataObject.push(answerResultObject);
                        });

                        context.setupMorrisBar(dataContainer, morrisDataObject);

                    } else if (surveyQuestionType == 2) {
                        //Convert the data to provide into the chart module
                        var morrisDataObject = [];

                        $.each(surveyResultsData, function (index, answerResult) {
                            var answerResultObject = { x: '', y: '' };
                            answerResultObject.x = index;
                            answerResultObject.y = answerResult;
                            morrisDataObject.push(answerResultObject);
                        });

                        context.setupMorrisBar(dataContainer, morrisDataObject);
                    } else if (surveyQuestionType == 3) {
                        var tableContainer = htmlComponents.tableComponent;
                        var tableRowsInsert = '';

                        //dataContainer.parent().addClass('height-7 scroll').css('max-height', '200px');
                        //dataContainer.css('max-height', '200px');
                        dataContainer.addClass('height-5 scroll')
                        dataContainer.html(tableContainer);

                        //Free Response Type
                        $.each(surveyResultsData, function (index, answerResult) {
                            //alert(answerResult);
                            var tableRow = htmlComponents.tableRowComponent;
                            var mapObj = {
                                FREERESPONSEDATA: answerResult
                            };

                            tableRow = tableRow.replace(/FREERESPONSEDATA/gi, function (matched) {
                                return mapObj[matched];
                            });
                            tableRowsInsert = tableRowsInsert + tableRow;
                        });

                        //Insert the rows
                        dataContainer.find('#tableBodyComponent').html(tableRowsInsert);
                    }
                });
            };
        });
    }


    context.setUpHeaderQuestions = function setUpHeaderQuestions(surveyHeaderId) {

        $.post(surveyURLs.getSurveyHeaderQuestionsURL, { surveyHeaderId: surveyHeaderId })
         .done(function (data) {
             var questionContainer = $('#questionContainer');
             var surveyQuestionsData = jQuery.parseJSON(data);
             var questionContainerInsert = '';

             //Check to see which type of question it is before outputting the question view
             $.each(surveyQuestionsData, function (index, questionDetail) {

                 var mapObj = {
                     SURVEYQUESTIONTITLE: questionDetail.pmsqd_arg1,
                     DETAILID: questionDetail.pmsqd_id,
                     QUESTIONTYPEID: questionDetail.pmsqd_pmsqh_id
                 };

                 var questionItem = htmlComponents.cardComponent.replace(/SURVEYQUESTIONTITLE|DETAILID|QUESTIONTYPEID/gi, function (matched) {
                     return mapObj[matched];
                 });

                 questionContainerInsert = questionContainerInsert + questionItem;

             });

             //Insert question html into the questino container
             questionContainer.html(questionContainerInsert);

             //Get survey question data from server and display it
             $('.questionTitle').on('click', function () {
                 //Check if the card parent is collapsed or expanded
                 if ($(this).parent().hasClass("card-collapsed")) {
                     var surveyQuestionId = $(this).attr('data-question-detail-id');
                     var surveyQuestionType = $(this).attr('data-question-type-id');
                     var dataContainer = $(this).next().find('.questionDetail');
                     //Get survey question results and display to user
                     $.post(surveyURLs.getSurveyQuestionResultsDataURL, { surveyQuestionId: surveyQuestionId })
                     .done(function (data) {
                         var surveyResultsData = jQuery.parseJSON(data);
                         if (surveyQuestionType == 1) {
                             //Convert the data to provide into the chart module
                             var morrisDataObject = [];

                             $.each(surveyResultsData, function (index, answerResult) {
                                 var answerResultObject = { x: '', y: '' };
                                 answerResultObject.x = index;
                                 answerResultObject.y = answerResult;
                                 morrisDataObject.push(answerResultObject);
                             });

                             surveyHelperFunctions.setupMorrisBar(dataContainer, morrisDataObject);

                         } else if (surveyQuestionType == 2) {
                             //Checklist Type
                             //Convert the data to provide into the chart module
                             var morrisDataObject = [];

                             $.each(surveyResultsData, function (index, answerResult) {
                                 var answerResultObject = { x: '', y: '' };
                                 answerResultObject.x = index;
                                 answerResultObject.y = answerResult;
                                 morrisDataObject.push(answerResultObject);
                             });

                             surveyHelperFunctions.setupMorrisBar(dataContainer, morrisDataObject);
                         } else if (surveyQuestionType == 3) {
                             var tableContainer = htmlComponents.tableComponent;
                             var tableRowsInsert = '';

                             //dataContainer.parent().addClass('height-7 scroll').css('max-height', '200px');
                             //dataContainer.css('max-height', '200px');
                             dataContainer.addClass('height-5 scroll')
                             dataContainer.html(tableContainer);

                             //Free Response Type
                             $.each(surveyResultsData, function (index, answerResult) {
                                 //alert(answerResult);
                                 var tableRow = htmlComponents.tableRowComponent;
                                 var mapObj = {
                                     FREERESPONSEDATA: answerResult
                                 };

                                 tableRow = tableRow.replace(/FREERESPONSEDATA/gi, function (matched) {
                                     return mapObj[matched];
                                 });
                                 tableRowsInsert = tableRowsInsert + tableRow;
                             });

                             //Insert the rows
                             dataContainer.find('#tableBodyComponent').html(tableRowsInsert);
                         }
                     });
                 } else {
                     //Clear out the details container otherwise there will be duplicate morris chart additions
                     $(this).next().find('.questionDetail').empty();
                 }
                 materialadmin.AppCard.toggleCardCollapse($(this).parent());
             });

         });
    }
})(surveyHelperFunctions);
