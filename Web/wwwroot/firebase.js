// Your web app's Firebase configuration
  var firebaseConfig = {
    apiKey: "AIzaSyCimPZhw6KMTluNh_XsKHDgOVeJoXU2bQs",
    authDomain: "onlinesaglikcim-bd3ec.firebaseapp.com",
    databaseURL: "https://onlinesaglikcim-bd3ec.firebaseio.com",
    projectId: "onlinesaglikcim-bd3ec",
    storageBucket: "onlinesaglikcim-bd3ec.appspot.com",
    messagingSenderId: "696486224235",
    appId: "1:696486224235:web:d5bdb68c2104670f1e6c2e",
    measurementId: "G-9WYCQ6W7N7"
  };
// Initialize Firebase
var defaultProject = firebase.initializeApp(firebaseConfig);
firebase.analytics();
var messaging = firebase.messaging();




var _token;
messaging.requestPermission()
    .then(function() {
        return messaging.getToken();
    })
    .then(function (token) {
        _token = token;
        $.ajax({
            url: '/Saglikcim/setNotifyToken',
            data: { token: token},
            type: 'post',
            dataType: 'json',
            success: function (data) {
                console.log("Başarılı kaydedildi");
            }
        });
		console.log(token);
    })
	.catch(function(err) {  
		console.log('Unable to get permission to notify.', err);
	});

// front-side site aktif olduğunda
messaging.onMessage(function (payload) {
    console.log(payload.data);
    var notification = new Notification(payload.data.title, {
        body: payload.data.body,
        icon: payload.data.icon,
        click_action:payload.data.click_action
    });
});


if ('serviceWorker' in navigator) {
  navigator.serviceWorker.register('../firebase-messaging-sw.js')
  .then(function(registration) {
    console.log('Registration successful, scope is:', registration.scope);
  }).catch(function(err) {
    console.log('Service worker registration failed, error:', err);
  });
}


// notification.onclick = function() {
//     window.open(payload.data.url);
// };