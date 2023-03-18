function Offers() {

    this.InitView = function ()
    {
        $("#btnCreateOffer").click(function () {
            var ofr = new Offers();
            ofr.GoToCreateOffer();

        });

        this.LoadOffersTable();
    }

    this.GoToCreateOffer = function () {
        location.href = "/Offer/CreateOffer";
    }

    this.LoadOffersTable = function () {
        var arrayColumns = [];
        arrayColumns[0] = { 'data': 'Id' };
        arrayColumns[1] = { 'data': 'Product' };
        arrayColumns[2] = { 'data': 'Description' };
        arrayColumns[3] = { 'data': 'Quantity' };
        arrayColumns[4] = { 'data': 'Price' };
        arrayColumns[5] = { 'data': 'Subscriptor.Name' };

        alert('cargando tabla');

        $('#tblOffers').DataTable({
            ajax: {
                method: "GET",
                url: "https://localhost:44396/api/Offer/GetallOffers",
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    console.log(json);
                    var jsonResult = { 'data': json }
                    console.log(jsonResult);
                    return jsonResult.data;
                }

            },
            columns: arrayColumns

        })

        //Manejar el click de cada row de la tabla para que muestre los datos en el formulario
        $('#tblOffers tbody').on('click', 'tr', function () {
            var tr = $(this).closest('tr');
            var data = $('#tblOffers').DataTable().row(tr).data();

            var actionsC = new ActionsControl();
            actionsC.BindFields("frmOffers", data);

        })

    }
}

$(document).ready(function () {
    var view = new Offers(); //Crea una instancia de nuestra funcion principal
    view.InitView(); //Llama a nuestro metodos para inicializar propiedades
})