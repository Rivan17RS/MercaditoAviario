function CreateOffer(){
    this.InitView = function () {
        $("#btnCreateOffer").click(function () {
            var ofr = new CreateOffer();
            ofr.SubmitOfferData();
        });

    }

    this.SubmitOfferData = function () {
        // Llamar al metodo que nos crea la oferta en el SINPAG

        var offer = {}
        offer.SubscriptorId = '202317';
        offer.Product = $('#txtProduct').val();
        offer.Description = $('#txtDescription').val();
        offer.Quantity = $('#txtQuantity').val();
        offer.Price = $('#txtPrice').val();

        var apiUrl = "https://localhost:44396/api/Offer/CreateOffer";

        //Llamado al API para que haga la creacion de la oferta
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: apiUrl,
            contentType: "application/json",
            data: JSON.stringify(offer),
            hasContent: true
        }).done(function (apiResult) {
            if (apiResult.Result === "OK")
                alert(apiResult.Message);
            else
                alert("Fallo " + apiResult.Message);
          
        }).fail(function () {
            alert('Hubo un problema al crear la oferta');
        });
    
        
    }

}

$(document).ready(function () {
    var view = new CreateOffer(); //Crea una instancia de nuestra funcion principal
    view.InitView(); //Llama a nuestro metodos para inicializar propiedades
})