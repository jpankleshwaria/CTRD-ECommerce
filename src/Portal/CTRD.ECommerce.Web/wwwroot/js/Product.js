CTRD.Product = {
    submitSearch: function (event) {
        event.preventDefault();

        var grid = document.getElementById('Product__Grid').ej2_instances[0];
        grid.showSpinner();
        var $form = $(event.target);
        var formData = $form.serializeArray();

        $.ajax('/Product/ProductList', { data: formData })
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            });
    },
    load: function () {
        
        // load temp data
        var grid = document.getElementById('Product__Grid').ej2_instances[0];
        grid.showSpinner();

        $.ajax('/Product/ProductList')
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            })
            .fail(function () {
                grid.hideSpinner();
                alert("Some error occurs to get Product List.");
            });
        //this.dataSource = serviceData;
    },
    actionBegin: function (args) {
        console.log('actionBegin', args.requestType);
        if (args.requestType === 'save') {
            var formValidatorOptions = {
                customPlacement: CTRD.Base.validationPlacement,
                rules: {
                    prodCatId: {
                        required: [true, 'Please select Product Category']
                    },
                    prodName: {
                        required: [true, 'Please enter Product Name'],
                        maxLength: [25, 'Product Name must be less than or equal to 25 characters']
                    },
                    prodDescription: {
                        maxLength: [200, 'Description must be less than or equal to 200 characters']
                    }
                }
            };

            var formValidator = new ej.inputs.FormValidator('#Product__GridEditForm', formValidatorOptions);

            args.cancel = !formValidator.validate();
        }
    },
    actionComplete: function (args) {
        console.log('actionComplete', args.requestType);
        

        if ((args.requestType === 'beginEdit' || args.requestType === 'add')) {

            let dialog = args.dialog;
            dialog.width = 600;
            dialog.header = args.requestType === 'beginEdit' ? 'Edit Product' : 'Add Product';

            let spinner = ej.popups.createSpinner({ target: args.dialog.element });
            ej.popups.showSpinner(args.dialog.element);

            let url = args.requestType === 'beginEdit' ? '/Product/Edit' : '/Product/Add';

            var ajax = new ej.base.Ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json'
            });
            ajax.send().then(function (data) {
                args.form.innerHTML = data;

                if (args.rowData.productId) {
                    var EleprodCategory = document.getElementById('EditProdCatId');
                    EleprodCategory.click();

                    var ajaxProductData = new ej.base.Ajax({
                        url: '/Product/GetProductById?productId=' + args.rowData.productId,
                        type: 'GET',
                        contentType: 'application/json'
                    });
                    ajaxProductData.send().then(function (data) {
                        var productData = JSON.parse(data);
                        var EleprodCat = EleprodCategory.ej2_instances[0];
                        EleprodCat.value = productData[0].prodCatId;
                        args.form.elements.prodName.value = productData[0].prodName;
                        args.form.elements.productId.value = productData[0].productId;
                        args.form.elements.prodDescription.value = productData[0].prodDescription;
                        console.log('all elements', args.form.elements);
                        args.form.elements.prodName.focus();
                        ej.popups.hideSpinner(args.dialog.element);
                    }).catch(function (xhr) {
                        console.log(xhr);
                        ej.popups.hideSpinner(args.dialog.element);
                    });
                } else {
                    ej.popups.hideSpinner(args.dialog.element);
                }

                var serverScript = args.form.querySelector('script');
                eval(serverScript.innerHTML);
            }).catch(function (xhr) {
                console.log(xhr);
                ej.popups.hideSpinner(args.dialog.element);
            });

        }
        else if (args.requestType === 'delete') {
            var delServicesData = JSON.parse(JSON.stringify(args.data));
            console.log('delete', delServicesData[0].serviceID);
           
        }
        else if (args.requestType === 'cancel') {

        }
        else if (args.requestType === 'save') {
            var productData = JSON.parse(JSON.stringify(args.data));
            
            $.post('/Product/Add', productData)
                .done(function (data) {
                    ej.popups.DialogUtility.alert('Successful save');
                    CTRD.Product.load();
                })
                .fail(function (data) {
                    ej.popups.DialogUtility.alert('Failed save');
                });
        }
    }
};
