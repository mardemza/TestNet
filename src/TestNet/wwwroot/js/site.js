(function () {

    // -- Init Angular
    var app = angular.module('app', [])
    .run(function () {
        console.log("Up Angular");
    });

    // -- Create Service
    app.factory('$taskService', ['$http', function ($http) {

        var urlBase = '/api/jobs'
        var taskFactory = {};

        // -- GetAll
        taskFactory.getAll = function () {
            return $http.get(urlBase);
        };

        // -- Get
        taskFactory.get = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        // -- Add
        taskFactory.add = function (task) {
            return $http.post(urlBase, task);
        };

        // -- Update
        taskFactory.update = function (task) {
            return $http.put(urlBase, task);
        };

        // -- Delete
        taskFactory.delete = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        return taskFactory;
    }]);

    // -- Controller for Task
    app.controller("taskController", ['$taskService', function ($taskService) {
        var vm = this;

        // -- Element for new and edit Task
        vm.taskNewOrEdit = null;
        vm.new = true;
        vm.projectId = location.search.replace("?id=", '');
        console.log(vm.projectId);
        // -- List of Tasks
        vm.tasks = [];
                
        vm.getAll = function () {
            $taskService.getAll().success(function (data) {
                console.log(data);
                vm.tasks = data;
            });
        }

        vm.addOrUpdate = function () {
            vm.taskNewOrEdit.projectId = vm.projectId;

            if (vm.new) {
                $taskService.add(vm.taskNewOrEdit).success(function () {
                    vm.getAll();
                });
            } else {
                $taskService.update(vm.taskNewOrEdit).success(function () {
                    vm.getAll();
                });
            }
        }        

        vm.delete = function (id) {
            $taskService.delete(id).success(function () {
                vm.getAll();
            });
        }

        vm.get = function (id) {
            if (id) {
                $taskService.get(id).success(function (data) {
                    vm.taskNewOrEdit = data;
                    vm.new = false;
                });
            } else {
                vm.taskNewOrEdit = null;
                vm.new = true;
            }
        }

        vm.getAll();
    }]);

})();
