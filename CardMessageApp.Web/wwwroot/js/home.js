var app = angular.module('app', ['ngSanitize']);

app.controller('CardMessageCtrl', ['$scope', '$http', function ($scope, $http) {

    // to and then from  - used to put controller data into scope so can use in angular 
    $.extend($scope, window.controllerData.DinnerModel);

    $scope.GetDinnerSuggestion = function () {


        $scope.Spinner = true;
        var model = {};
        model.Occasion = $scope.SelectedOccasion;
        model.Age = $scope.SelectedAge;
        model.Name = $scope.Name;
        model.Relation = $scope.SelectedRelation;
        model.AtrributesListing = $scope.PersonalityAttListing;
        model.Poetic = $scope.MakeItPoetic;
        $http.post('/Home/GetMessage', model).then(
            function (response) {

                $scope.Spinner = false;
                //$scope.showHeadings = true;
                if (response.data.wasSuccess) {
                    // $scope.SuggestedMeal = response.data.mealName;
                    // $scope.HowToMake = response.data.gptFullResponse;
                    $scope.ServerResponse = response.data.Message;


                } else {
                    $scope.ErrorMsg = "there was a problem";
                    $scope.showHeadings = false;
                }
                $scope.$digest();


            }
        );
    };

}]);