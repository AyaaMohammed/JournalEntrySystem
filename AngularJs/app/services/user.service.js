app.service("UserService", function($http) {
    var baseUrl = "https://localhost:7260/api/User/Api/v1/User";

    this.getAll = function() {
        return $http.get(baseUrl + "/GetAll");
    };
});
