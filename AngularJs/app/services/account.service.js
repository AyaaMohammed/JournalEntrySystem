app.service('AccountService', function($http) {
    this.getAccounts = function() {
      return $http.get("https://localhost:7260/api/Account/Api/v1/Account/GetAll");
    };
  });
