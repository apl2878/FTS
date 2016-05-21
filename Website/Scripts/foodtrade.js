(function ($) {
    $.FTCommon = {
        LoadList: function(type)
        {
            var app = angular.module("MeApp", []);
            app.controller("MeController", function ($scope, $http) {
                $http.get('http://localhost:2409/api/' + type).
                  success(function (data, status, headers, config) {
                      $scope.items = data;
                  }).
                  error(function (data, status, headers, config) {
                      alert("Oops! Something went wrong.");
                  });
            });
        },
        LoadNew: function (type) {
            var app = angular.module("MeApp", []);
            app.controller("MeController", ['$scope', '$http', function ($scope, $http) {
                $scope.submit = function () {
                var data = $.FTCommon.ConstructDataFields($scope);
                $http.post('http://localhost:2409/api/' + type , data).
                success(function (data, status, headers, config) {
                    alert('Saved Successfully');
                    window.location.href = "../" + type + "s/index.html";
                }).
                error(function (data, status, headers, config) {
                    alert("Oops! Something went wrong");
                });
                };

            }]);
        },
        LoadDetail: function (type)
        {
            var app = angular.module("MeApp", []);
            app.controller("MeController", ['$scope', '$http', function ($scope, $http) {
                $http.get('http://localhost:2409/api/' + type + '/' + $.FTCommon.getUrlParameter("ID")).
                  success(function (data, status, headers, config) {
                      $scope.item = data;
                  }).
                  error(function (data, status, headers, config) {
                      alert("Oops! Something went wrong.");
                  });
                $scope.submit = function () {
                var data = $.FTCommon.ConstructDataFields($scope);
                $http.put('http://localhost:2409/api/' + type + '/' + $scope.item.ID, data).
                success(function (data, status, headers, config) {
                    alert('Updated Successfully');
                    window.location.href = "../" + type + "s/index.html";
                }).
                error(function (data, status, headers, config) {
                    alert("Oops! Something went wrong");
                });
                };

            }]);
        },
        LoadDelete: function (type) {
            var app = angular.module("MeApp", []);
            app.controller("MeController", ['$scope', '$http', function ($scope, $http) {
                $http.get('http://localhost:2409/api/' + type + '/' + $.FTCommon.getUrlParameter("ID")).
                  success(function (data, status, headers, config) {
                      $scope.item = data;
                  }).
                  error(function (data, status, headers, config) {
                      alert("Oops! Something went wrong.");
                  });
                $scope.submit = function () {
                    if ($scope.item.ID) {
                        $http.delete('http://localhost:2409/api/' + type + '/' + $scope.item.ID).
                        success(function (data, status, headers, config) {
                            alert('Deleted Successfully');
                            window.location.href = "../" + type + "s/index.html";
                        }).
                        error(function (data, status, headers, config) {
                            alert("Oops! Something went wrong");
                        });
                    }
                };

            }]);
        },
        getUrlParameter: function(sParam) {
            var sPageURL = decodeURIComponent(window.location.search.substring(1)),
                sURLVariables = sPageURL.split('&'),
                sParameterName,
                i;

            for (i = 0; i < sURLVariables.length; i++) {
                sParameterName = sURLVariables[i].split('=');

                if (sParameterName[0] === sParam) {
                    return sParameterName[1] === undefined ? true : sParameterName[1];
                }
            }
        },
        ConstructDataFields: function(scope)
        {
            var data = {};
            angular.forEach(scope.item, function (value, index) {
                data[index] = value;
            })
            return data;
        },
    };
}(jQuery));