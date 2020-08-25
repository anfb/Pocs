import {Request, Response } from 'express';
import createUser from './services/CreateUser';

export function helloWorld(request: Request, response: Response){
    const user = createUser({
        name: 'Adriely',
        email: 'anfb@cin.ufpe.br',
        password: '23232323',
        techs: [
            'Node.js', 
            'java' , 
            'C#',
            {title: 'Javascript', experience: 80},
            {title: 'Java', experience: 90},
        ],
    });

    return response.json({user});
}