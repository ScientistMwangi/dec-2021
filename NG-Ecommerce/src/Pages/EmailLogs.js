import React, {useState, useEffect} from 'react';
import { getData } from '../Service';
import {useTokenContext} from '../Store/AppContext';

const EmailLog =()=>{

    // use context token
    const token = useTokenContext();
    // Local State
    const [logs, setLogs] = useState();
    useEffect(() => {
        getData("api/system-configs/get-email-logs", setLogs, token);
      },[]);

    return(
         <div className='container'>   
        <h4 className='mb-4'>Email Logs</h4>
        <table className='table table-bordered table-hover table-responsive-sm'>
          <thead>
            <tr>
              <th scope='col'>#</th>
              <th scope='col'>To</th>
              <th scope='col'>Status</th>
              <th scope='col'>Content</th>
              <th scope='col'>Exception Issue</th>
              <th scope='col'>Sent Date</th>
            </tr>
          </thead>
          <tbody>
              {logs && logs.results.map((log)=>{
                   return(
                    <tr>
                    <td>{log.id}</td>
                    <td>{log.emailTo}</td>
                    <td>{log.emailContent.substr(0,10)+" ..."}</td>
                    <td>{log.emailStatus == 1 ? "Sent" :" Failed"}</td>
                    <td>{log.exceptionIssue == null ? log.exceptionIssue : log.exceptionIssue.substr(0,10)}</td>
                    <td>{log.dateCreated}</td>
                </tr>
                   ) 
              })}
                
          </tbody>
        </table>
      </div>

    );
}
export default EmailLog;