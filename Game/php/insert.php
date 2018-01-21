<?php
	$servername = "localhost";
	$username = "root";
	$password = "starmy00h";
	$dbName = "rankdatabase";

	$id=$_POST["id_post"];
	$score=$_POST["score_post"];

	$conn = new mysqli($servername, $username, $password, $dbName);

	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	else echo("Connection Success!");

	$sql = "INSERT INTO rank (id,score) VALUES ('".$id."','".$score."')";
	if ($conn->query($sql) === TRUE){
		echo "success";
	}
	else{
		echo "error";
	}

	$conn->close();

?>