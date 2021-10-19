<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				
    xmlns="http://tempuri.org/TechCollage.xsd"
    xmlns:mstns="http://tempuri.org/TechCollage.xsd"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
	exclude-result-prefixes="mstns xs"
>
    <xsl:output method="html" indent="yes" encoding="utf-8"/>
	<xsl:template match="/mstns:root">
		<xsl:variable name="lectureAmount" select="count(mstns:lectures)"></xsl:variable>

		<html>
			<body>
				<p>
					Amount: <xsl:value-of select="$lectureAmount"/>
				</p>
				<table>
					<tr>
						<th>Teacher</th>
						<th>Class</th>
						<th>Taught</th>
					</tr>
					<xsl:for-each select="mstns:lectures">
						<tr>
							<td>
								<xsl:value-of select="mstns:teacher"/>
							</td>
							<td>
								<xsl:value-of select="mstns:class"/>
							</td>
							<td>
								<xsl:value-of select="mstns:isTaught"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
