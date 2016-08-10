// Instanciation
var point = new google.maps.LatLng(position.coords.latitude,position.coords.longitude),
// Ajustement des paramètres
myOptions = {
    zoom: 15,
    center: point,
    mapTypeId: google.maps.MapTypeId.ROADMAP
},
// Envoi de la carte dans la div
mapDiv = document.getElementById("mapDiv"),
map = new google.maps.Map(mapDiv, myOptions),
//Ajouter un marker pour la position
marker = new google.maps.Marker({
    position: point,
    map: map,
    // Texte du point
    title: "Vous êtes ici"
});

//navigation
var seltravMode = document.getElementById("selType").value;
var travMode = google.maps.TravelMode.DRIVING;
switch(seltravMode)
{
    case "DRIVING": travMode = google.maps.TravelMode.DRIVING; break;
    case "WALKING": travMode = google.maps.TravelMode.WALKING; break;
}
//Si on désire calculer un itinéraire
var directionsDisplay = new google.maps.DirectionsRenderer();
directionsDisplay.setMap(map);
//Point de départ
var current_pos = new google.maps.LatLng(50.814202, 4.266016);
//Point d’arrivée
var end_pos = new google.maps.LatLng(position.coords.latitude,
position.coords.longitude);
var request = {
    origin: current_pos,
    destination: end_pos,
    travelMode: seltravMode
};
var directionsService = new google.maps.DirectionsService();
directionsService.route(request, function (result, status) {
    if (status == google.maps.DirectionsStatus.OK)
    {
        directionsDisplay.setDirections(result);
        //Obtenir les informations (distance, temps,…)
        var distance = result.routes[0].legs[0].distance.text;
        var duree = result.routes[0].legs[0].duration.text;
    }
});