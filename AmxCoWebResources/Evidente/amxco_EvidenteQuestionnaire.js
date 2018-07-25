function getParams(searchUrl) {
    var result = {};
    var tmp = [];

    var search = "";
    if (searchUrl == undefined)
        search = location.search;
    else
        search = "?" + searchUrl;

    search
        .substr(1)
        .split("&")
        .forEach(function (item) {
            tmp = item.split("=");
            result[tmp[0]] = decodeURIComponent(tmp[1]);
        });

    return result;
}
location.getParams = getParams;

var amxco_EvidenteQuestionnaire = {
    IE: (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0),
    header: null,
    quizContainer: null,
    errorContainer: null,
    resultsContainer: null,
    submitButton: null,
    closeButton: null,
    myQuestions: null,
    myAnswers: null,
    codeQuestionnaire: null,
    questionnaireSequence: null,
    fullName: null,
    identificationNumber: null,
    codeIdentificationType: null,


    OnLoad: function () {
        amxco_EvidenteQuestionnaire.header = document.getElementById("header");
        amxco_EvidenteQuestionnaire.quizContainer = document.getElementById("quiz");
        amxco_EvidenteQuestionnaire.resultsContainer = document.getElementById("results");
        amxco_EvidenteQuestionnaire.submitButton = document.getElementById("submit");
        amxco_EvidenteQuestionnaire.closeButton = document.getElementById("close");
        amxco_EvidenteQuestionnaire.errorContainer = document.getElementById("lblError");


        //amxco_EvidenteQuestionnaire.dialog = document.getElementById('evidenteDialog');
        //if (!amxco_EvidenteQuestionnaire.IE)
        //    amxco_EvidenteQuestionnaire.dialog.showModal();

        // on submit, show results
        //amxco_EvidenteQuestionnaire.submitButton.addEventListener("click", amxco_EvidenteQuestionnaire.showResults);
        //amxco_EvidenteQuestionnaire.closeButton.addEventListener("click", amxco_EvidenteQuestionnaire.closeForm);

        // Load Questionnaire from Evidente
        amxco_EvidenteQuestionnaire.LoadQuestionnaire();
    },

    closeForm: function () {
        //if (!amxco_EvidenteQuestionnaire.IE) {
        //    amxco_EvidenteQuestionnaire.dialog.close();
        //}
        //else {
        //    parent.postMessage(true, '*');
        //    close();
        //}
        if (window.opener != null && !window.opener.closed) {
            window.opener.homeAppointmentCheck();
        }
        close();
    },

    buildQuiz: function () {

        // we'll need a place to store the HTML output
        const output = [];

        if (amxco_EvidenteQuestionnaire.myQuestions == undefined || amxco_EvidenteQuestionnaire.myQuestions == null) {
            amxco_EvidenteQuestionnaire.errorContainer.innerHTML = "preguntas no encontradas!";
            return;
        }

        try {
            // for each question...
            amxco_EvidenteQuestionnaire.myQuestions.forEach(function (currentQuestion, questionNumber) {
                // we'll want to store the list of answer choices
                const answers = [];

                // and for each available answer...
                for (letter in currentQuestion.answers) {
                    // ...add an HTML radio button
                    var radioButton = "<label>"
                        + "<input type=\"radio\" name=\"question" + questionNumber + "\" value=\"" + letter + "\""
                        + " sequenceanswer=\"" + currentQuestion.answers[letter].sequenceAnswer + "\""
                        + " sequencequestion=\"" + currentQuestion.answers[letter].sequenceQuestion + "\">"
                        + currentQuestion.answers[letter].text
                        + "</label>";

                    answers.push(radioButton);
                }

                // add this question and its answers to the output
                output.push(
                    "<div class=\"question\">" + currentQuestion.text + "</div>" +
                    "<div class=\"answers\">" + answers.join("") + " </div>");
            });

            // finally combine our output list into one string of HTML and put it on the page
            amxco_EvidenteQuestionnaire.quizContainer.innerHTML = output.join("");
        }
        catch (err) {
            amxco_EvidenteQuestionnaire.errorContainer.innerHTML = "buildQuiz: " + err.message;
        }
    },

    showResults: function () {
        try {
            // gather answer containers from our quiz
            const answerContainers = amxco_EvidenteQuestionnaire.quizContainer.querySelectorAll(".answers");

            // keep track of user's answers
            let numCorrect = 0;

            amxco_EvidenteQuestionnaire.myAnswers = [];

            if (amxco_EvidenteQuestionnaire.myQuestions == undefined || amxco_EvidenteQuestionnaire.myQuestions == null) {
                alert("no hay respuestas para enviar!");
                return;
            }

            // for each question...
            amxco_EvidenteQuestionnaire.myQuestions.forEach(function (currentQuestion, questionNumber) {
                // find selected answer
                const answerContainer = answerContainers[questionNumber];
                const selector = "input[name=question" + questionNumber + "]:checked";
                const userAnswer = (answerContainer.querySelector(selector) || {}).value;
                if (userAnswer != undefined) {
                    const userSequenceAnswer = answerContainer.querySelector(selector).attributes["sequenceanswer"].value;
                    const userSequenceQuestion = answerContainer.querySelector(selector).attributes["sequencequestion"].value;

                    var answer = {};
                    answer.SequenceQuestion = userSequenceQuestion;
                    answer.SequenceAnswer = userSequenceAnswer;

                    amxco_EvidenteQuestionnaire.myAnswers.push(answer);
                }
            });

            if (amxco_EvidenteQuestionnaire.myAnswers.length != amxco_EvidenteQuestionnaire.myQuestions.length) {
                alert("Responda todas las preguntas!");
                return;
            }

            amxco_EvidenteQuestionnaire.EvaluateQuestionnaire();
        }
        catch (err) {
            amxco_EvidenteQuestionnaire.errorContainer.innerHTML = "showResults: " + err.message;
        }
    },

    LoadQuestionnaire: function () {
        debugger;
        console.log(location.getParams());
        var data = location.getParams()["data"];
        console.log(data);
        //var individualCustomerId = getParams(data)["individualCustomerId"];
        //console.log(individualCustomerId);

        //parameters = Xrm.Page.context.getQueryStringParameters();

        //var customparams = amxco_EvidenteQuestionnaire.ParseData(parameters.data);
        var customparams = amxco_EvidenteQuestionnaire.ParseData(data);
        var individualCustomerId = customparams.individualcustomerid;

        if (individualCustomerId == undefined || individualCustomerId == null) {
            alert("Missing parameter: individualCustomerId");
            return;
        }

        var WorkflowUrlName = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxCoEvidenteGetQuestionnaire";
        var status = "";
        //TO DO
        var request = {
            "request": {
                "$type": "AmxCoPSBActivities.Model.Evidente.AmxCoGetQuestionnaireRequest, AmxPeruPSBActivities",
                "ContactId": individualCustomerId
            }
        };

        amxco_EvidenteQuestionnaire.ServiceCall(request, WorkflowUrlName, amxco_EvidenteQuestionnaire.LoadQuestionnaire_Callback);
    },

    LoadQuestionnaire_Callback: function (data) {
        if (data.Output.response.Success) {
            amxco_EvidenteQuestionnaire.myQuestions = data.Output.response.Questions;

            amxco_EvidenteQuestionnaire.codeQuestionnaire = data.Output.response.codeQuestionnaire;
            amxco_EvidenteQuestionnaire.questionnaireSequence = data.Output.response.questionnaireSequence;
            amxco_EvidenteQuestionnaire.fullName = data.Output.response.fullName;
            amxco_EvidenteQuestionnaire.identificationNumber = data.Output.response.identificationNumber;
            amxco_EvidenteQuestionnaire.codeIdentificationType = data.Output.response.codeIdentificationType;

            amxco_EvidenteQuestionnaire.header.innerHTML = amxco_EvidenteQuestionnaire.fullName;

            //display quiz right away
            amxco_EvidenteQuestionnaire.buildQuiz();
        }
        else {
            amxco_EvidenteQuestionnaire.errorContainer.innerHTML = data.Output.response.Error;
        }
    },

    EvaluateQuestionnaire: function () {
        var WorkflowUrlName = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxCoEvidenteEvaluateQuestionnaire";
        var status = "";

        var request = {
            "request": {
                "$type": "AmxCoPSBActivities.Model.Evidente.AmxCoEvaluateQuestionnaireRequest, AmxPeruPSBActivities",
                "codeQuestionnaire": amxco_EvidenteQuestionnaire.codeQuestionnaire,
                "questionnaireSequence": amxco_EvidenteQuestionnaire.questionnaireSequence,
                "identificationNumber": amxco_EvidenteQuestionnaire.identificationNumber,
                "codeIdentificationType": amxco_EvidenteQuestionnaire.codeIdentificationType,
                "answers": amxco_EvidenteQuestionnaire.myAnswers
            }
        };

        amxco_EvidenteQuestionnaire.ServiceCall(request, WorkflowUrlName, amxco_EvidenteQuestionnaire.EvaluateQuestionnaire_Callback);
    },

    EvaluateQuestionnaire_Callback: function (data) {
        if (data && data.Output && data.Output.response && data.Output.response.Success) {

            // eheldma: UC_MIC_GEN_TCRM_005
            // Mark customer as fraudulent

            if (data.Output.response.responseCode == "0") {
                try {

                    $scope.workflowUpdateListInput = {
                        "individualCustomerId": individualCustomerId,
                        "orderId": "",
                        "idReason": "248"
                    };

                    $http.post(apiUrl + 'AmxCoUpdateList', JSON.stringify($scope.workflowBureauInput), config)
                        .success(function (result) {
                            if (result) {
                                var UpdateListResponse = result.Output.response;
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                            $scope.httpLoading = false;
                        });
                }
                catch (err) {
                    alert("Error al marcar cliente com riesgo de fraude ");
                }
            }

            if (data.Output.response.responseCode == "0") {
                alert("Dialogo:\nSr./Sra. la autenticación no ha sido exitosa. Desafortunadamente no se pudo continuar con la venta\nPor favor acercarse a un punto de atención presencial");
                //if (window.opener != null && !window.opener.closed) {
                //    window.opener.redirectTo360View();
                //}
                parent.Alert.getCrmWindow().redirectTo360View();
                close();
            }
            else if (data.Output.response.responseCode == "1")
            {
                alert("Dialogo:\nSr./Sra. la autenticación ha sido exitosa.");
                close();
            }
            else {
                alert("responseCode:"+data.Output.response.responseCode+" descriptionCode: "+data.Output.response.descriptionCode);
                close();
            }
        }
        else {
            alert(data.Output.response.Error);
        }
    },

    ServiceCall: function (request, WorkflowUrlName, success_callback) {
        $.ajax({
            type: "POST",
            url: WorkflowUrlName,
            dataType: "json",
            data: JSON.stringify(request),
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            xhrFields:
            {
                withCredentials: true
            },
            crossDomain: true,
            success: function (data) {
                if (data && success_callback != undefined) {
                    success_callback(data);
                }
            },
            error: function (data) {
                var errorMessage = "";
                if (data.status != undefined && data.status != null)
                    errorMessage += data.status;

                if (data.statusText != undefined && data.statusText != null)
                    errorMessage += ("-" + data.statusText + "\n");

                if (data.responseText != undefined && data.responseText != null)
                    errorMessage += data.responseText;

                alert(errorMessage);
            }
        });
    },

    ParseData: function (query) {
        var result = {};

        if (typeof query == "undefined" || query == null) {
            return result;
        }

        var queryparts = query.split("&");
        for (var i = 0; i < queryparts.length; i++) {
            var params = queryparts[i].split("=");
            result[params[0].toLowerCase()] = params.length > 1 ? params[1] : null;
        }
        return result;
    }
}

