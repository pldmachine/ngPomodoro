import { Injectable } from '@angular/core'
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { IProject } from '../model/project-interface'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class DataService {
    baseUrl: string = '/api/projects';


    constructor(private http: Http) { }

    insertProject(project: IProject): Observable<IProject> {
        return this.http.post(this.baseUrl, project)
            .map((res: Response) => {
                const data = res.json();
                console.log('insertProject status: ' + data.status);
                return data.project;
            })
            .catch(this.handleError);
    }

    private handleError(error: any) {
        console.error('server error:', error);
        if (error instanceof Response) {
            let errMessage = '';
            try {
                errMessage = error.json().error;
            } catch (err) {
                errMessage = error.statusText||'';
            }
            return Observable.throw(errMessage);
            // Use the following instead if using lite-server
            //return Observable.throw(err.text() || 'backend server error');
        }
        return Observable.throw(error || 'ASP.NET Core server error');
    }
}