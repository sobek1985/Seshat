EntityService.utils.validator.add("notPastDate", function (value, params) {
    var result = false;

    var currentDate = new Date();
    result = value >= currentDate;

    return result;
});