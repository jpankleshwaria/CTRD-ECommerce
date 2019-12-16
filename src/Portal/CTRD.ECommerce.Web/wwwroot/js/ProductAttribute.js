CTRD.ProductAttribute = {
    submitSearch: function (event) {
        event.preventDefault();

        var grid = document.getElementById('ProductAttribute__Grid').ej2_instances[0];
        grid.showSpinner();
        var $form = $(event.target);
        var formData = $form.serializeArray();

        $.ajax('/ProductAttribute/ProductAttributeList', { data: formData })
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            });
    },
    load: function () {

        // load temp data
        var grid = document.getElementById('ProductAttribute__Grid').ej2_instances[0];
        grid.showSpinner();

        $.ajax('/ProductAttribute/ProductAttributeList')
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            })
            .fail(function () {
                grid.hideSpinner();
                alert("Some error occurs to get Attribute List.");
            });
        //this.dataSource = serviceData;
    },
    actionBegin: function (args) {
        console.log('actionBegin', args.requestType);
        console.log('check action args', args);
        if (args.requestType === 'save') {
            var formValidatorOptions = {
                customPlacement: CTRD.Base.validationPlacement,
                rules: {
                    prodCatId: {
                        required: [true, 'Please select Product Category Name']
                    },
                    productId: {
                        required: [true, 'Please select Product Name']
                    },
                    attributeId: {
                        required: [true, 'Please select Attribute Name']
                    },
                    attributeValue: {
                        required: [true, 'Please enter Attribute Value'],
                        maxLength: [200, 'Attribute Value must be less than or equal to 200 characters']
                    }
                }
            };

            var formValidator = new ej.inputs.FormValidator('#ProductAttribute__GridEditForm', formValidatorOptions);

            args.cancel = !formValidator.validate();
        }
    },
    actionComplete: function (args) {
        console.log('actionComplete', args.rowData);

        if ((args.requestType === 'beginEdit' || args.requestType === 'add')) {

            let dialog = args.dialog;
            dialog.width = 600;
            dialog.header = args.requestType === 'beginEdit' ? 'Edit Product Attribute' : 'Add Product Attribute';

            let spinner = ej.popups.createSpinner({ target: args.dialog.element });
            ej.popups.showSpinner(args.dialog.element);

            let url = args.requestType === 'beginEdit' ? '/ProductAttribute/Edit' : '/ProductAttribute/Add';

            var ajax = new ej.base.Ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json'
            });
            ajax.send().then(function (data) {
                args.form.innerHTML = data;

                if (args.rowData.productId) {
                   
                    var ajaxServiceData = new ej.base.Ajax({
                        url: '/ProductAttribute/GetProductAttributeById?productId=' + args.rowData.productId + '&prodAttributeId=' + args.rowData.attributeId,
                        type: 'GET',
                        contentType: 'application/json'
                    });
                    ajaxServiceData.send().then(function (data) {
                        var attrData = JSON.parse(data);

                        args.form.elements.prodAttrId.value = attrData[0].prodAttrId;
                        args.form.elements.categoryName.value = attrData[0].categoryName;
                        args.form.elements.prodCatId.value = attrData[0].prodCatId;
                        args.form.elements.productName.value = attrData[0].prodName;
                        args.form.elements.productId.value = attrData[0].productId;
                        args.form.elements.attributeName.value = attrData[0].attributeName;
                        args.form.elements.attributeId.value = attrData[0].attributeId;
                        args.form.elements.EditAttributeValue.value = attrData[0].attributeValue;

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
            var attributeData = JSON.parse(JSON.stringify(args.data));

            $.post('/ProductAttribute/Add', attributeData)
                .done(function (data) {
                    ej.popups.DialogUtility.alert('Successful save');
                    CTRD.ProductAttribute.load();
                })
                .fail(function (data) {
                    ej.popups.DialogUtility.alert('Failed save');
                });
        }
    },
    prodCatChange: function () {
        // load temp data
        var dropDownProdCat = document.getElementById('AddProdCatId').ej2_instances[0];
        var paramVal = dropDownProdCat.value;

        var dropDownProd = document.getElementById('AddProdId').ej2_instances[0];
        dropDownProd.showSpinner();
        dropDownProd.dataSource = '';
        dropDownProd.value = null;
        
        $.ajax('/Product/GetProductsByCatId?prodCatId=' + paramVal)
            .done(function (data) {
                // populate the grid with our test data
                dropDownProd.dataSource = data;
                dropDownProd.dataBind();
                dropDownProd.enabled = true;
                dropDownProd.hideSpinner();
            })
            .fail(function () {
                dropDownProd.hideSpinner();
                alert("Some error occurs to get Product List.");
            });


        var dropDownProdAttr = document.getElementById('AddAttributeId').ej2_instances[0];
        dropDownProdAttr.showSpinner();
        dropDownProdAttr.dataSource = '';
        dropDownProdAttr.value = null;
        
        $.ajax('/ProductAttributeLookup/GetProductAttributeLookupsByProdCatId?prodCatId=' + paramVal)
            .done(function (data) {
                // populate the grid with our test data
                dropDownProdAttr.dataSource = data;
                dropDownProdAttr.dataBind();
                dropDownProdAttr.enabled = true;
                dropDownProdAttr.hideSpinner();
            })
            .fail(function () {
                dropDownProdAttr.hideSpinner();
                alert("Some error occurs to get Attribute List.");
            });
    },
    prodChange: function (args) {
        let prodID = args.value;
        let grid = document.getElementById('ProductAttribute__Grid').ej2_instances[0]; // Grid instance
        let url = '/ProductAttribute/GetProductAttributeByProdId?productId=' + prodID;
        let ajax = new ej.base.Ajax(url, 'GET');
        grid.showSpinner();
        ajax.send();
        ajax.onSuccess = function (data) {
            grid.dataSource = ej.data.DataUtil.parse.parseJson(data);
            grid.refresh();
            grid.hideSpinner();
        };
        ajax.onFailure = function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 500) {
                CTRD.Dialog.showError(jqXHR.responseText)
            }
            else if (jqXHR.status == 400) {
                CTRD.Dialog.showError(jqXHR.responseJSON.join('\n'))
            }
            CTRD.Dialog.showError(data)
            grid.hideSpinner();
        };
    }
};
