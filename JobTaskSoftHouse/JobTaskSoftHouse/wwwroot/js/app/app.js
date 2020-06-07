
var app = angular.module('JobApp', ['ui.bootstrap', 'ui.grid']);

app.controller('TodosListController', [
    '$scope',
    '$rootScope',
    '$q',
    '$modal',
    '$http',
    'TodosService',
    function ($scope, $rootScope, $q, $modal, $http, TodosService) {
       
        $scope.todos = [];

        $scope.init = function () {
            TodosService.getTodos()
                .then(function (res) {
                    $scope.todos = res.data;
                })
        }
            
        // Initialize scope properties and functions
        angular.extend($scope, {
            add: add,
            open: open
        });

        function open(id) {
            return TodosService.open(id);
        }

        function add() {
            console.log($modal);
            $uidModal.open({
                template: '<h1>Sta ima</h1>'
            })
        }
    }
]);



app.directive('addTodo', function () {
    var whatSave = {
        userId: 1,
        id: 1,
        title: 1,
        completed: 1
    };
    return {
        restrict: 'E',
        template: `<h1>Hellou</h1>`,
        scope: false,
        link: function (scope, element, attrs, ctrl) {

            angular.extend(scope, {
                save: save
            });

            function save(infoFormIsValid) {
                if (!infoFormIsValid) {
                    return new Notification.warning($$('ocd.formValidation.error'));
                }

                var plan = ctrl.mergePlan(whatSave, scope.webuser);
                return ctrl.update(scope.uid, plan);
            }

        }
    };
}
);


app.factory('TodosService', [
    '$rootScope',
    '$q',
    '$modal',
    '$http',
    function ($rootScope, $q, $modal, $http) {

        return {
            getTodos: function () {
                return $http.get('/Todos/GetAll').then(function (res) {
                    return res;
                })
            },
            open: function (id) {
                if (!id) return;

                var modalConfig = angular.extend({
                    template: '<h1>sta ima</h1>'
                });

                modalConfig.scope = $rootScope.$new(true);

                modalConfig.scope.id = id;
                modalConfig.scope.todos = {};

                modalInstance = $modal.open(modalConfig);

                modalInstance.result.finally(function () {
                    $rootScope.$broadcast('list.refresh');
                });

                modalConfig.scope.close = function () {
                    modalInstance.close();
                    modalInstance = null;
                };

                return modalInstance;
            }

        }
    }
]);