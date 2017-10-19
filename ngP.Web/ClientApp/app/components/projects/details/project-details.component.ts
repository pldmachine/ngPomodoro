import { Component } from "@angular/core";
import { IProject } from "../../../model/project-interface";
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../../../services/data.service';

@Component({
    templateUrl:'./project-details.component.html'
})
export class ProjectDetailsComponent
{
    operationText: string = 'Insert';
    errorMessage: string;

    model: IProject = {
        name: ''
    }

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    submit() {
        this.dataService.insertProject(this.model)
           .subscribe((project: IProject) => {
                if (project) {
                    this.router.navigate(['/projects']);
                }
                else {
                    this.errorMessage = 'Unable to add project';
                }
            },
            (err: any) => console.log(err));
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/projects']);
    }
}