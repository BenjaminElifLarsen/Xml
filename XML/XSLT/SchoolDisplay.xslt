<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				
    xmlns="http://tempuri.org/Education.xsd"
    xmlns:mstns="http://tempuri.org/Education.xsd"
	exclude-result-prefixes="mstns"
>
  <xsl:output method="html" indent="yes" encoding="utf-8"/>
  <xsl:template match="/mstns:education">
    <xsl:variable name="lectureAmount" select="count(mstns:lectures)"></xsl:variable>
    <xsl:variable name="schoolAmount" select="count(mstns:School)"></xsl:variable>
    <html>
      <body>
        <dev>
        <xsl:for-each select="mstns:School">
          <h1><xsl:value-of select="mstns:school"/></h1>
          <h2>Overall Inforamtion</h2>
          <table>
            <tr>
              <th>Teacher</th>
              <th>Class</th>
              <th>Taught</th>
            </tr>
            <xsl:for-each select="mstns:lectures">
              <xsl:sort select="mstns:teacher"/>
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
          <h2>Class Information</h2>
          <dev>
            <h2>
              Classes
            </h2>
            <xsl:for-each select="mstns:lectures">
              <h3>
                <xsl:value-of select="mstns:class"/>
              </h3>
              <p>
                <b>Teacher: </b>
                <xsl:value-of select="mstns:teacher"/>
              </p>
              <p>
                <b>Total Students: </b>
                <xsl:value-of select="count(mstns:student)"/>
              </p>
              <table>
                <tr>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>Grade</th>
                </tr>
                <xsl:for-each select="mstns:student">
                  <xsl:sort select="mstns:grades"/>
                  <tr>
                    <td>
                      <xsl:value-of select="mstns:firstName"/>
                    </td>
                    <td>
                      <xsl:value-of select="mstns:lastName"/>
                    </td>
                    <td>
                      <xsl:value-of select="mstns:grade"/>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </xsl:for-each>
          </dev>
        </xsl:for-each>
        </dev>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
