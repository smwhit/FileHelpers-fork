@echo off
@rmdir /S /Q "FileHelpers\obj"
@rmdir /S /Q "FileHelpersTests\obj" 
@rmdir /S /Q "FileHelpersTests\Release" 
@rmdir /S /Q "FileHelpersSamples\Release"
@rmdir /S /Q "FileHelpersSamples\obj"
@rmdir /S /Q "FileHelpers.CodeExamples\Example CSharp\obj"
@rmdir /S /Q "FileHelpers.CodeExamples\Example VbNet\obj"
@rmdir /S /Q "FileHelpers.CodeExamples\Example CSharp - VS 2005\obj"
@rmdir /S /Q "FileHelpers.CodeExamples\Example VbNet - VS 2005\obj"
@rmdir /S /Q "FileHelpers.CodeExamples\Release"
@rmdir /S /Q "FileHelpers.ExcelStorage\bin"
@rmdir /S /Q "FileHelpers.ExcelStorage\obj"
@rmdir /S /Q "FileHelpers.WizardApp\obj"
@rmdir /S /Q "FileHelpers.DB2Storage\obj"
@rmdir /S /Q "CloverBuild"
@rmdir /S /Q "CloverReport"
@rmdir /S /Q "Release"
@rmdir /S /Q "ReleaseDemo"
@del /AH /Q "FileHelpers.suo"
@del /F /Q "FileHelpers.ExcelStorage\FileHelpers.ExcelStorage.xml"
@del /F /Q "FileHelpers\FileHelpers.xml"
@del /F /Q "FileHelpers\FileHelpersPPC.xml"
@del /F /Q FileHelpers.resharperoptions
@del /F /Q FileHelpers.Wizard.resharper.user 
@del /F /Q "FileHelpers.CodeExamples\*.suo"
@del /F /Q "Doc\Include\Thumbs.db"
