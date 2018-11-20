(function ($) {

    function feedViewModel() {
        var self = this;
        this.model = ko.observable($.parseJSON(entryModel));
        this.feed = ko.observable([]);
        this.init = function () {
            $.ajax({
                url: '/Feed/GetLastFeed',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
            }).done(function (data) {
                self.feed(data);
            });
        };
    }

    $(document).ready(function () {
        var feedModel = new feedViewModel();
        feedModel.init();
        ko.applyBindings(feedModel, document.getElementById("feedContext"));
    });

})(jQuery);
