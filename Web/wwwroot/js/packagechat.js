function mesajGonder() {
	var emptyCheck = document.getElementById("mesajKutusu").value;
	if(emptyCheck==""){
		document.getElementById("mesajKutusu").placeholder = "Bu alanı boş bırakamazsınız...";
	}
	else{
		const div = document.createElement('div');
		var mesaj = document.getElementById("mesajKutusu").value;
		var check = document.getElementById("isDoctor").checked;
		var currentdate = new Date(); 
		var datetime =  currentdate.getDate() + "/"
		                + (currentdate.getMonth()+1)  + "/" 
		                + currentdate.getFullYear() + " @ "  
		                + currentdate.getHours() + ":"  
		                + currentdate.getMinutes() + ":" 
		                + currentdate.getSeconds();
		if(check==true){
			div.innerHTML = '<li class="me">' +
						'<div class="entete">' +
						'<h3> '+datetime+'</h3>' +
						'<h2>Doktor </h2>' +
						'<span class="status blue"></span>' +
						'</div>' +
						'<div class="triangle"></div>' +
						'<div class="message">' +
						mesaj + 
						'</div>' +
						'</li>';
		}
		else{
					div.innerHTML = '<li class="you">' +
						'<div class="entete">' +
						'<span class="status green"></span>' +					
						'<h2>Sami Kısakürek </h2>' +
						'<h3> '+datetime+'</h3>' +
						'</div>' +
						'<div class="triangle"></div>' +
						'<div class="message">' +
						mesaj + 
						'</div>' +
						'</li>';
		}
	  document.getElementById("chat").append(div);
	  document.getElementById("mesajKutusu").value='';
	  document.getElementById("mesajKutusu").placeholder = "Mesajınızı girin...";
	}
}
