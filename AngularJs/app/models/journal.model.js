app.factory('JournalModel', function() {
  function Journal(data) {
    data = data || {};
    this.systemNo = data.systemNo || '';
    this.entryDate = data.entryDate ? new Date(data.entryDate) : new Date();
    this.transactionType = data.transactionType || '';
    this.documentNo = data.documentNo || '';
    this.description = data.description || '';
    this.user_ID = data.user_ID || 0;
    this.filePath = data.filePath || '';
    this.journalDetails = data.journalDetails || [];
  }
  return Journal;
});
