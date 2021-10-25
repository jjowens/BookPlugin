angular.module("umbraco")
    .controller("BooksPlugin.BooksController",
        // inject umbracos assetsService
        function ($scope, $http) {

            $scope.Books = [];
            $scope.TotalBooks = 0;

            $scope.GetBooks = function () {
                $http.post("/umbraco/BooksPlugin/Bookshop/GetBooks")
                    .then(function (response) {
                        $scope.Books = response.data.Results;
                    });
            }

            $scope.GetBooks();

        });