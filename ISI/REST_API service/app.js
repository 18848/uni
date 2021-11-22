const express = require('express');
var mysql = require('mysql');

var con = mysql.createConnection({
  host: "localhost",
  port: "3306",
  user: "root",
  password: ""
});

con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");
});

const app = express();

app.get("/", (req, res) => {
    res.send("Introduçao a API");
})

app.listen(8080, () => {
    console.log("Server Started port 8080");
})