jQuery(document).ready(function () {
    //Get the first survey header provided by the view and list out the questions of the header
    var firstSurveyHeaderItem = $('.surveyHeaderItem').first();

    if (firstSurveyHeaderItem.length == 0) {
        alert('No surveys in this app.');
    } else {
        //Get the survey questions of the survey header and display them
        var surveyHeaderId = firstSurveyHeaderItem.attr('data-survey-id');

        surveyHelperFunctions.setUpHeaderQuestions(surveyHeaderId);

        $('.surveyHeaderItem').on('click', function () {
            var surveyHeaderId = $(this).attr('data-survey-id');
            surveyHelperFunctions.setUpHeaderQuestions(surveyHeaderId);
        });
    }

    $('#refreshBtn').on('click', function () {
        surveyHelperFunctions.refreshData();
    });

    $('#checkPasswordBtn').on('click', function () {
        var passwordInput = $('#passwordInput').val();
        var projectId = $('#projectBody').attr('data-project-id');
        $.post('/other/custom/CMSSurvey/validateSurveyPassword', { projectId: projectId, password: passwordInput }).done(function (data) {
            if (data == 'true') {
                $('#passwordModal').remove();
            } else {
                alert('Incorrect Password Provided');
            }
        });

    })
});