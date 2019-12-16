CTRD.ProductAttributeLookup = {
    submitSearch: function (event) {
        event.preventDefault();

        var grid = document.getElementById('ProductAttributeLookup__Grid').ej2_instances[0];
        grid.showSpinner();
        var $form = $(event.target);
        var formData = $form.serializeArray();

        $.ajax('/ProductAttributeLookup/ProductAttributeLookupList', { data: formData })
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            });
    },
    load: function () {

        // load temp data
        var grid = document.getElementById('ProductAttributeLookup__Grid').ej2_instances[0];
        grid.showSpinner();

        $.ajax('/ProductAttributeLookup/ProductAttributeLookupList')
            .done(function (data) {
                // populate the grid with our test data
                grid.dataSource = data;
                grid.hideSpinner();
                grid.refresh();
            })
            .fail(function () {
                grid.hideSpinner();
                alert("Some error occurs to get Service List.");
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
                    serviceName: {
                        required: [true, 'Please enter Service Name'],
                        maxLength: [25, 'Service Name must be less than or equal to 25 characters']
                    },
                    note: {
                        maxLength: [200, 'Note must be less than or equal to 200 characters']
                    }
                }
            };

            var formValidator = new ej.inputs.FormValidator('#ProductAttributeLookup__GridEditForm', formValidatorOptions);

            args.cancel = !formValidator.validate();
        }
    },
    actionComplete: function (args) {
        console.log('actionComplete', args.requestType);

        if ((args.requestType === 'beginEdit' || args.requestType === 'add')) {

            let dialog = args.dialog;
            dialog.width = 600;
            dialog.header = args.requestType === 'beginEdit' ? 'Edit Service' : 'Add Service';

            let spinner = ej.popups.createSpinner({ target: args.dialog.element });
            ej.popups.showSpinner(args.dialog.element);

            let url = args.requestType === 'beginEdit' ? '/ProductAttributeLookup/Edit?serviceId=' + args.rowData.serviceID : '/ProductAttributeLookup/Add';

            var ajax = new ej.base.Ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json'
            });
            ajax.send().then(function (data) {
                args.form.innerHTML = data;

                if (args.rowData.serviceID) {
                    var ajaxServiceData = new ej.base.Ajax({
                        url: '/ProductAttributeLookup/GetServiceById?serviceId=' + args.rowData.serviceID,
                        type: 'GET',
                        contentType: 'application/json'
                    });
                    ajaxServiceData.send().then(function (data) {
                        var serviceData = JSON.parse(data);

                        args.form.elements.EditServiceName.value = serviceData[0].serviceName;
                        args.form.elements.serviceID.value = serviceData[0].serviceID;
                        //alert(serviceData[0].isActive);
                        //args.form.elements.EditActive.checked = serviceData[0].isActive;

                        //if (serviceData[0].isActive) {
                        //    args.form.elements.EditActive.click();
                        //}
                        args.form.elements.EditExpiryDate.value = new Date(serviceData[0].expiryDate).toLocaleDateString();
                        args.form.elements.note.value = serviceData[0].note;

                        args.form.elements.EditServiceName.focus();
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
            var serviceData = JSON.parse(JSON.stringify(args.data));
            serviceData.expiryDate = new Date(serviceData.expiryDate).toDateString();
            $.post('/ProductAttributeLookup/Add', serviceData)
                .done(function (data) {
                    ej.popups.DialogUtility.alert('Successful save');
                    CTRD.ProductAttribute.load();
                })
                .fail(function (data) {
                    ej.popups.DialogUtility.alert('Failed save');
                });
        }
    }
};
