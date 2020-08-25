"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.helloWorld = void 0;
var CreateUser_1 = __importDefault(require("./services/CreateUser"));
function helloWorld(request, response) {
    var user = CreateUser_1.default({
        name: 'Adriely',
        email: 'anfb@cin.ufpe.br',
        password: '23232323',
        techs: [
            'Node.js',
            'java',
            'C#',
            { title: 'Javascript', experience: 80 },
            { title: 'Java', experience: 90 },
        ],
    });
    return response.json({ user: user });
}
exports.helloWorld = helloWorld;
