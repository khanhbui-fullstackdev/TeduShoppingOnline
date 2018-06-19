var feedBack = {
    init: function () {
        feedBack.registerEvent();
    },
    registerEvent: function () {
        var successMessage = $("#successMessage").text();
        if (successMessage) {
            // Set empty string for input text fields
            $("#feedBackName").val("");
            $("#feedBackEmail").val("");
            $("#feedBackMessage").val("");
        }
    }
};

feedBack.init();
