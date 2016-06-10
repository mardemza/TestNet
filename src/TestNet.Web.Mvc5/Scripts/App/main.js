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
        taskFactory.getAll = function (projectId) {

            if (projectId) {
                return $http.get(urlBase + '?projectId=' + projectId);
            }

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

        // -- Get Users for Asigned
        taskFactory.getUsers = function () {
            return $http.get('/users');
        }

        return taskFactory;
    }]);

    // -- Controller for Task
    app.controller("taskController", ['$taskService', function ($taskService) {
        var vm = this;

        // -- Element for new and edit Task
        vm.taskNewOrEdit = {};
        vm.new = true;
        vm.projectId = location.pathname.split('/')[location.pathname.split('/').length - 1];
        vm.createdUserId = CreatedUserId;
        vm.taskNewOrEdit.createdUserId == vm.createdUserId;


        // -- List of Tasks
        vm.tasks = [];
        vm.users = [];

        $taskService.getUsers().success(function (data) {
            vm.users = data;
        });

        vm.cancel = function () {
            vm.taskNewOrEdit = {};
            vm.new = true;
            vm.taskNewOrEdit.createdUserId == vm.createdUserId;
        }
        
        vm.getAll = function () {
            $taskService.getAll(vm.projectId).success(function (data) {
                console.log(data);
                vm.tasks = data;
            });
        }

        vm.addOrUpdate = function () {
            vm.taskNewOrEdit.ProjectId = vm.projectId;
            vm.taskNewOrEdit.CreatedUserId = vm.createdUserId;

            if (vm.new) {
                $taskService.add(vm.taskNewOrEdit).success(function () {
                    vm.getAll();
                    vm.cancel();
                });
            } else {
                $taskService.update(vm.taskNewOrEdit).success(function () {
                    vm.getAll();
                    vm.cancel();
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
                    data.start = data.startFormated;
                    data.end = data.endFormated;
                    vm.taskNewOrEdit = data;
                    vm.new = false;
                });
            } else {
                VM.cancel();
            }
        }

       

        vm.getAll();
    }]);

})();
