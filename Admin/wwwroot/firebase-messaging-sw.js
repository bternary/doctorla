importScripts("https://www.gstatic.com/firebasejs/7.12.0/firebase-app.js");
importScripts("https://www.gstatic.com/firebasejs/7.12.0/firebase-messaging.js");

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

var defaultProject = firebase.initializeApp(firebaseConfig);

var messaging = firebase.messaging();

// Burası arkaplanda çalışan kısım aynı kodlar iki tarafta da var burayla bağımsız diğeri onmessage da  bak aynısı içerik
messaging.setBackgroundMessageHandler(function(payload){
   var notificationTitle = payload.data.title;
   var notificationOptions = {
       body: payload.data.body,
       icon: payload.data.icon,
       click_action:payload.data.click_action
   };
   return self.registration.showNotification(notificationTitle,notificationOptions);
});