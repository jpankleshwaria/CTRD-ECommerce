// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var CTRD = {};

CTRD.Base = {
    init: function () {
        console.log('CTRD.Base.init()');
        ej.base.enableRipple(true);

        document.body.classList.remove('loading');

        switch (window.location.pathname) {
            case '/Product':
                var grid = document.getElementById('Product__Grid').ej2_instances[0];
                grid.showSpinner();
                break;
            case '/ProductAttribute':
                var grid = document.getElementById('ProductAttribute__Grid').ej2_instances[0];
                grid.showSpinner();
                break;
            case '/ProductAttributeLookup':
                var grid = document.getElementById('ProductAttributeLookup__Grid').ej2_instances[0];
                grid.showSpinner();
                break;
            case '/ProductCategory':
                var grid = document.getElementById('ProductCategory__Grid').ej2_instances[0];
                grid.showSpinner();
                break;
            default:
                // code block
                console.log(window.location.pathname, 'url', window.location.href);
        }

    },
    validationPlacement: function (inputElement, error) {
        error.classList.add('e-helper-text');
        inputElement.parentNode.appendChild(error);
    },
};

CTRD.Dialog = {
    showSuccess: function (text) {
        CTRD.Dialog.show(text, 'success', 'done');
    },
    showSuccessWithEvent: function (text, confirmCallback) {
        CTRD.Dialog.show(text, 'successwithevent', 'done', confirmCallback);
    },
    showError: function (text) {
        CTRD.Dialog.show(text, 'error', 'priority_high');
    },
    showInfo: function (text) {
        CTRD.Dialog.show(text, 'info', 'notifications');
    },
    showConfirm: function (text, confirmCallback, cancelCallback) {
        CTRD.Dialog.show(text, 'confirm', 'notifications', confirmCallback, cancelCallback);
    },
    show: function (text, type, icon, confirmCallback, cancelCallback) {
        let content;
        if (type === 'confirm') {
            content = '<p class="message-text">' + text + '</p> \
                <button id="MessageDialogOkBtn" class="e-secondary" style="width: 65px">Yes</button> \
                <button id="MessageDialogCancelBtn" class="e-primary e-outline" style="width: 65px">No</button>';
        }
        else {
            content = '<span class="message-icon"><i class="material-icons">' + icon + '</i></span> \
                <p class="message-text">'+ text + '</p> \
                <button id="MessageDialogOkBtn" class="e-secondary">Ok</button>';
        }

        let dialog = new ej.popups.Dialog({
            cssClass: 'text-center dialog-' + type,
            content: content,
            width: '400px',
            isModal: true,
            visible: true,
            overlayClick: function () { dialog.destroy(); },
            beforeOpen: function () {
                if (type === 'confirm') {
                    let okBtn = new ej.buttons.Button();
                    let cancelBtn = new ej.buttons.Button();
                    okBtn.appendTo('#MessageDialogOkBtn');
                    cancelBtn.appendTo('#MessageDialogCancelBtn');
                    okBtn.element.onclick = function () { confirmCallback(); dialog.destroy(); };
                    cancelBtn.element.onclick = function () { cancelCallback(); dialog.destroy(); };
                }
                else if (type === 'successwithevent') {
                    let btn = new ej.buttons.Button();
                    btn.appendTo('#MessageDialogOkBtn');
                    btn.element.onclick = function () { confirmCallback(); dialog.destroy(); };
                }
                else {
                    let btn = new ej.buttons.Button();
                    btn.appendTo('#MessageDialogOkBtn');
                    btn.element.onclick = function () { dialog.destroy(); };
                }
            },
            close: function () { dialog.destroy(); }
        });

        let dialogContainer = document.getElementById('MessageDialog');
        if (!dialogContainer) {
            dialogContainer = document.createElement('div');
            dialogContainer.id = 'MessageDialog';
            document.getElementsByTagName('body')[0].appendChild(dialogContainer);
        }

        dialog.appendTo('#MessageDialog');
    }
};