(function ($) {    

    function entryViewModel() {
        var self = this;
        this.entryModel = ko.validatedObservable(null);
        this.AvailableFood = ko.observable([]);
        this.createFoodViewModel = ko.observable(null);

        this.init = function () {
            $.ajax({
                url: '/Entry/InitModel',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
            }).done(function (data) {
                self.entryModel = new entryModel(data);
                self.AvailableFood(data.AvailableFood);
            });
        }

        this.addFood = function () {
            var element = document.getElementById("foodCreateModal");
            var createModel = new createFoodViewModel();
            createModel.init();
            self.createFoodViewModel(createModel);
            ko.applyBindings(createModel, element);
        }

        this.reportToAll = function () {
            var modelData = {
                Name: self.entryModel.Name,
                Email: self.entryModel.Email,
                FoodId: self.entryModel.FoodId,
                AvailableFood: self.AvailableFood
            }
            $.ajax({
                url: '/Entry/Report',
                data: ko.toJSON(modelData),
                type: 'POST',
                dataType: 'JSON',
                contentType: 'application/json',
                async: false
            }).done(function (result) {
                window.location = result.url;
            });
        }
    }

    var entryModel = ko.validatedObservable({        
        Name: ko.observable().extend({ required: true }),
        Email: ko.observable().extend({ required: true }),
        FoodId:ko.observable().extend({ required: true }),
    })

    function createFoodViewModel() {
        var self = this;
        this.model = ko.observable(null);

        this.init = function () {
            $.ajax({
                url: '/Entry/CreateNewFood',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
            }).done(function (data) {
                self.model(data);
            }).always(function () {
                $("#foodCreateModal").modal();
            });
        };
        this.save = function () {
            var self = this;
            var data = { food: self.model() };
            if (self.availableFood().indexOf(self.model()) > -1) {
                $.ajax({
                    url: '/Entry/SaveFood',
                    data: ko.toJSON(data),
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json'
                }).always(function () {
                    $("#foodCreateModal").modal('hide');
                });
            }
        }
    }
    

    function updateInfo() {
        var entryModel = new entryViewModel();
        entryModel.init();
        ko.applyBindingsWithValidation(entryModel, document.getElementById("entryContext"), {
            insertMessages: false,
            errorElementClass: 'text-danger'
        });
    }

    $(document).ready(function () {
        ko.validation.init({
            registerExtenders: true,
            messagesOnModified: true,
            insertMessages: true,
            parseInputAttributes: true,
            errorClass: 'errorStyle',
            messageTemplate: null
        }, true); 
        updateInfo();
    });    

})(jQuery);