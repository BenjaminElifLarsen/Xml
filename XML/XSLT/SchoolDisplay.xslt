<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				
    xmlns="http://tempuri.org/Education.xsd"
    xmlns:mstns="http://tempuri.org/Education.xsd"
	exclude-result-prefixes="mstns"
>
	<xsl:output method="html" indent="yes" encoding="utf-8"/>
	<xsl:template match="/mstns:Education">
		<xsl:variable name="schoolAmount" select="count(mstns:Schools)"></xsl:variable>
		<html>
			<body>
				<dev>
					<xsl:for-each select="mstns:Schools">
						<h1>
							<xsl:value-of select="mstns:Name"/>
						</h1>
						<h2>Teacher Information</h2>
						<table>
							<tr>
								<th>Id</th>
								<th>Name</th>
							</tr>
							<xsl:for-each select="mstns:Teachers">
								<xsl:sort select="mstns:Id"/>
								<tr>
									<td>
										<xsl:value-of select="mstns:Id"/>
									</td>
									<td>
										<xsl:value-of select="mstns:Name"/>
									</td>
								</tr>
							</xsl:for-each>
						</table>
						<dev>
							<h2>Teams</h2>
							<xsl:for-each select="mstns:Teams">
								<h3>
									<xsl:value-of select="mstns:Name"/>
								</h3>
								<p>
									<b>Id: </b>
									<xsl:value-of select="mstns:Id"/>
								</p>
								<h3>Lecture Ids</h3>
								<ul>
									<xsl:for-each select="mstns:Lectures">
										<li>
											<xsl:value-of select="mstns:Id"/>
										</li>
									</xsl:for-each>
								</ul>
								<h3>Students</h3>
								<table>
									<tr>
										<th>Id</th>
										<th>First Name</th>
										<th>Last Name</th>
										<th>Grade</th>
									</tr>
									<xsl:for-each select="mstns:Student">
										<xsl:sort select="mstns:Grades"/>
										<tr>
											<td>
												<xsl:value-of select="mstns:Id"/>
											</td>
											<td>
												<xsl:value-of select="mstns:FirstName"/>
											</td>
											<td>
												<xsl:value-of select="mstns:LastName"/>
											</td>
											<td>
												<xsl:value-of select="mstns:Grade"/>
											</td>
										</tr>
									</xsl:for-each>
								</table>
							</xsl:for-each>
						</dev>
						<dev>
							<h2>Lecture Information</h2>
							<xsl:for-each select="mstns:Lectures">
								<h3>
									<xsl:value-of select="mstns:Name"/>
								</h3>
								<p>
									<b>Id: </b>
									<xsl:value-of select="mstns:Id"/>
								</p>
								<p>
									<b>TeacherId: </b>
									<xsl:value-of select="mstns:TeacherId"/>
								</p>
								<p>
									<b>Room: </b>
									<xsl:value-of select="mstns:Room"/>
								</p>
								<p>
									<b>Is Taught: </b>
									<xsl:value-of select="mstns:IsTaught"/>
								</p>
							</xsl:for-each>
						</dev>
					</xsl:for-each>
				</dev>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
