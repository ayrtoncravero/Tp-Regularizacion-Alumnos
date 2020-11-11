﻿//Js necesario para hacer la pre-visualizacion de la carga de la imagen
$("#selectionImg").change(function () {
    readURL(this);
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#image").attr("src", e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}