function iniciarMap() {
    var coord = { lat: -33.6942128, lng: -71.2136897 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: coord
    });
    var marker = new google.maps.Marker({
        position: coord,
        map: map
    });
}