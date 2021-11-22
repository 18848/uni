const express = require('express');

const app = express();

app.get("/", (req, res) => {
    res.send("Introduçao a API");
})

app.listen(8080, () => {
    console.log("Server Started port 8080");
})