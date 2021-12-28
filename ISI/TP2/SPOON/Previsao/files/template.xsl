<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
    <h1>Previsão</h1>   
	<style type="text/css">
		table, th, td {
		  border: 1px solid black;
		}
		.tg  {vertical-align:middle;text-align:center;}
		.tg td{
			font-family:Arial, sans-serif;
			font-size:14px;
			padding:10px 5px;
			word-break:normal;
			}
		.tg th{
			background-color:#333333;
			font-family:Arial, sans-serif;
			font-size:14px;
			font-weight:bold;
			color:#f0f0f0;
			padding:10px 5px;
			word-break:normal;
			}
		.tg .tg-9wq8{background-color:#CACACA;text-align:center;vertical-align:middle;word-break:normal;}
		.tg .tg-kyy7{background-color:#CACACA;text-align:center;vertical-align:middle;word-break:normal;}	
	@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;}}
	</style> 
	
	<table class="tg">
		<thead>
			<tr>
				<th rowspan="2">Data</th>
				<th colspan="2" scope="colgroup">Temperatura</th>
				<th rowspan="2">longitude</th>
				<th rowspan="2">latitude</th>
				<th rowspan="2">Precipitação</th>
				<th rowspan="2">Probabilidade</th>
				<th rowspan="2">Vento</th>
				<th rowspan="2">Direção</th>
				<th rowspan="2">Clima</th>
			</tr>
			<tr>
				<th scope="col">Min</th>
				<th scope="col">Max</th>
			</tr>
		</thead>
		
		<tbody>
			<xsl:for-each select="Forecast/Day">
		<tr>
		<td><xsl:value-of select="@data" /></td>
		<td><xsl:value-of select="Min" /></td>
		<td><xsl:value-of select="Max" /></td>
		<td><xsl:value-of select="longitude" /></td>
		<td><xsl:value-of select="latitude" /></td>
		<td bgcolor="#CACACA"><xsl:value-of select="Precipitação" /></td>
		<td><xsl:value-of select="Probabilidade" /></td>
		<td bgcolor="#CACACA"><xsl:value-of select="Vento" /></td>
		<td><xsl:value-of select="Direção" /></td>
		<td bgcolor="#CACACA"><xsl:value-of select="Clima" /></td>
		</tr>
		</xsl:for-each>
		</tbody>
	</table>
    
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
