angular.module('app', [])
.controller("QuizController", function ($scope, $http) {

    $scope.Init = function () {
        $scope.InitText = "Iniciar";
        $scope.NextAction = "Próxima Bandeira!";
        $scope.started = false;
        $scope.answered = false;
        $scope.message = "";
        $scope.Summary = [];
        $scope.currentFlag = 1;
        $scope.answers = [];
    }

    $scope.Init();

    $scope.Start = function () {
        $scope.Init();
        $scope.Next();
    }

    $scope.Next = function () {

        $scope.started = true;
        
        if ($scope.currentFlag < 10) {
            $scope.NextAction = "Próxima Bandeira!";
            $scope.getQuestion();
        } else {
            $scope.NextAction = "Resultado Geral";
            $scope.getResult();
        }
    }

    $scope.getQuestion = function () {

        var link = 'Flags/' + $scope.currentFlag;

        $http.get(link, {}).then(function (result) {

            $scope.currentFlag++;
            $scope.answered = false;
            $scope.Question = result.data;

        }).catch(function (erro) {
            console.log(erro);
        });

    }

    $scope.getAnswer = function (option) {

        var link = 'Flags/Answer';

        var answer = new Object();

        answer.Id = $scope.currentFlag;
        answer.Value = option;

        $http.post(link, answer, {}).then(function (result) {

            $scope.answered = true;
            $scope.answers.push(result.data.Answer);

        }).catch(function (erro) {
            console.log(erro);
        });

    }

    $scope.getResult = function () {

        $http.post('Flags/Result', $scope.answers, {}).then(function (resultado) {

            $scope.InitText = "Reiniciar";
            $scope.message = "Resultado: ";
            $scope.Summary = resultado.data.Summary;
            $scope.started = false;
            $scope.currentFlag = 1;

        }).catch(function (erro) {
            console.log(erro);
        });

    }

});