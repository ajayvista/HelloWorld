#Reference
#install pandoc to generate doc to md file
#https://stackoverflow.com/questions/39956497/pandoc-convert-docx-to-markdown-with-embedded-images

#Install widdershins to generate markdown from swagger
#https://mermade.github.io/widdershins/ConvertingFilesBasicCLI.html#:~:text=The%20simplest%20way%20to%20convert,with%20the%20Widdershins%20JavaScript%20interface.
#####################

echo "genrating version history"
git tag -l "cao-*" -n99 > docs/_version-history1.md
sed 's/.*/&<\/br>/'  docs/_version-history1.md > docs/_version-history2.md
sed 's/^/- /' docs/_version-history2.md > docs/version-history.md

echo "genrating functional documents"
pandoc --extract-media=docs/images -f docx -t gfm "docs/functional.docx" -o docs/_functional.md
sed 's/docs\/images\/media/images\/media/g' docs/_functional.md > docs/functional.md

echo "converting swagger to markdown"
curl -k docs/swagger.json > docs/_swagger.json

widdershins --lang false docs/_swagger.json --summary -v -c -o docs/apis.md

docfx build -t docs/docfx.json 

rm -rf docs/_*

