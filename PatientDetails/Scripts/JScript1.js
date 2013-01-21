var test_Helper = Class.create({
    initialize: function () {
        this.attachEvents();
    },


    attachEvents: function () {
        $$('.patientName').each(function(item) {
            item.observe("click", this._getPatientInfo.bind(this, item.id));
        }, this),
        $$('.PatientEdit').each(function(item) {
            item.observe("click", this._getPatient.bind(this, item.id));
        }, this),
        $$('.patientDelete').each(function(item) {
            item.observe("click", this._DeletePatient.bind(this, item.id));
        }, this);
    },




    _getPatientInfo: function (id) {

        new Ajax.Updater($('Partialview'), '/Patient/PatientDetails',
            {
                method: 'get',
                encoding: "UTF-8",
                parameters: { id: id },
                onSuccess: this._getPatientInfoSuccess.bind(this)
            });
    },

    _getPatientInfoSuccess: function (response) {



    },
    _getPatient: function (id) {

        new Ajax.Updater($('PatientEdit'), '/Patient/EditPatient',
            {
                method: 'get',
                encoding: "UTF-8",
                parameters: { id: id },
                onSuccess: this._getPatientSuccess.bind(this)
            });

    },
    _getPatientSuccess: function (response) {


    },
    _DeletePatient:function (id) {
        new Ajax.Updater($('PatientDelete'), '/Patient/PatientDelete',
            {
                method: 'get',
                encoding: "UTF-8",
                parameters: { id: id },
                onSuccess: this._DeletePatientSuccess.bind(this)
            });
                
    },
    
    _DeletePatientSuccess:function (response) {
        
    }
});



