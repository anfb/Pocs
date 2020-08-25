### Configurando projeto do zero com typescript

Crie um novo diretório para o projeto
`mkdir basicsabouttypescript`

Dentro da pasta inicialize o projeto com 
`yarn init -y`

Instale o typescript ao projeto como uma dependência de desenvolvimento 
`yarn add typescript`

Aproveite e instale também o express:
`yarn add express`

Instale o pacote de declaração de tipos do typescript para importar o express:
`yarn add @types/express -D`

Vamos criar o arquivo de configuração do typescript
`yarn tsc --init`

Assim que o arquivo tsconfig.json for criado, vamos alterar o valor do **"outDir"** para **"outDir": "./dist"**.

Para poder executar a aplicação precisamos converter os arquivos typescript em arquivos javascript
`yarn tsc`

Execute o app com 
`node dist/index.js`






