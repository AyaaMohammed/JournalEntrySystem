app.service('JournalService', function($http) {
    this.addJournal = function(journal) {
      return $http.post("https://localhost:7260/api/Journal/Api/v1/Journal/Add", journal);
    };
  });
