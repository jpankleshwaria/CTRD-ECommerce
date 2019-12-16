CTRD.ProductCategory = {
    submitSearch: function (event) {
        event.preventDefault();

        var grid = document.getElementById('ProductCategory__Grid').ej2_instances[0];
        grid.showSpinner();
        var $form = $(event.target);
        var formData = $form.serializeArray();

        $.ajax('/ProductCategory/ProductCategoryList', { data: formData })
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            });
    },
    load: function () {
        
        // load temp data
        var grid = document.getElementById('ProductCategory__Grid').ej2_instances[0];
        grid.showSpinner();

        $.ajax('/ProductCategory/ProductCategoryList')
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            })
            .fail(function () {
                grid.hideSpinner();
                alert("Some error occurs to get Product Category List.");
            });
        //this.dataSource = serviceData;
    },
    actionBegin: function (args) {
        console.log('actionBegin', args.requestType);
        
    },
    actionComplete: function (args) {
        console.log('actionComplete', args.requestType);

    }
};
