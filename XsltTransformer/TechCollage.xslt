<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes" encoding="utf-8"/>
	<xsl:template match="/">
		<xsl:variable name="lectureAmount" select="count(/lectures)"></xsl:variable>

		<html>
			<body>
				<p>
					test: <xsl:value-of select="$lectureAmount"/>
				</p>
				<table>
					<tr>
						<th>Teacher</th>
						<th>Class</th>
						<th>Taught</th>
					</tr>
					<xsl:for-each select="root/lectures">
						<tr>
							<td>
								<xsl:value-of select="teacher"/>
								<xsl:value-of select="class"/>
								<xsl:value-of select="isTaught"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
