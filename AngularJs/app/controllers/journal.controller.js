app.controller('JournalController', function($scope, AccountService, JournalService, UserService) {
    
    var savedJournal = localStorage.getItem("journalData");
    if (savedJournal) {
        try {
            $scope.journal = JSON.parse(savedJournal);
            $scope.journal.entryDate = new Date($scope.journal.entryDate);
            $scope.journal.journalDetails = [];
        } catch (e) {
            console.error("Error parsing saved journal:", e);
        }
    } else {
       $scope.journal = {
            systemNo: "",
            entryDate: new Date(),
            transactionType: "",      
            documentNo: "",
            description: "",
            user_ID: null,
            filePath: "",
            journalDetails: []
        };
    }

    $scope.accounts = [];
    $scope.users = [];


    AccountService.getAccounts().then(res => $scope.accounts = res.data.data || []);
    UserService.getAll().then(res => $scope.users = res.data.data || []);

 
    $scope.addDetail = function() {
      if ($scope.journal.journalDetails.length >= 4) {
        alert("لا يمكنك إضافة أكثر من 4 صفوف فقط");
        return;
      }
      $scope.journal.journalDetails.push({
        accountID: "",
        accountNumber: "",
        accountName: "",
        lineDescription: "",
        reportDescription: "",
        debit: 0,
        credit: 0
      });
      $scope.saveToLocal(); 
    };


    $scope.removeDetail = function(index) {
        if (confirm("هل أنت متأكد من حذف هذا السطر؟")) {
            $scope.journal.journalDetails.splice(index, 1);
            $scope.saveToLocal();
        }
    };

    $scope.setAccountName = function(detail) {
        var account = $scope.accounts.find(a => a.number === detail.accountNumber);
        if (account) {
            detail.accountID = account.id;
            detail.accountName = account.nameEN;
            $scope.saveToLocal();
        }
    };


    $scope.getTotalDebit  = () => $scope.journal.journalDetails.reduce((s, d) => s + (parseFloat(d.debit) || 0), 0);
    $scope.getTotalCredit = () => $scope.journal.journalDetails.reduce((s, d) => s + (parseFloat(d.credit) || 0), 0);
    $scope.getDifference  = () => $scope.getTotalDebit() - $scope.getTotalCredit();

    $scope.saveToLocal = function() {
        localStorage.setItem("journalData", JSON.stringify($scope.journal));
    };
$scope.today = new Date().toISOString().split("T")[0];
    $scope.saveJournal = function(form) {
        form.$setSubmitted();

        if (form.$invalid) {
            alert(" من فضلك اكمل الحقول المطلوبة");
            return;
        }

        if ($scope.getDifference() !== 0) {
            alert(" لا يمكن الحفظ إلا إذا كان الفرق = صفر");
            return;
        }
    if ($scope.getTotalDebit() <= 100 || $scope.getTotalCredit() <= 100) {
        alert("المبلغ المدين أو الدائن يجب أن يكون أكبر من 100");
        return;
    }
        JournalService.addJournal($scope.journal)
            .then(function(res) {
                alert("تم الحفظ بنجاح!");
                var newId = res.data.data;

                 localStorage.removeItem("journalData");

                var url = "https://localhost:7260/api/Journal/Api/v1/Journal/Print/" + newId;
                window.open(url, "_blank");
            })
            .catch(function(err) {
                console.error("Error saving journal:", err);
                alert("حصل خطأ أثناء الحفظ!");
            });
    };
$scope.$watch('journal', function(newVal) {
    if (newVal) {
        localStorage.setItem("journalData", JSON.stringify(newVal));
    }
}, true);
});
