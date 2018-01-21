<?php
	$servername = "localhost";
	$username = "root";
	$password = "starmy00h";
	$dbName = "rankdatabase";

	$conn = new mysqli($servername, $username, $password, $dbName);

	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}

	$sql = "SELECT id, score FROM rank ORDER BY score DESC LIMIT 5";
	$result = $conn->query($sql);

	if($result->num_rows > 0){
		while($row = $result->fetch_assoc()){
			echo $row['id']. " (".$row['score']. ")|";
		}
	}

	$conn->close();
?>